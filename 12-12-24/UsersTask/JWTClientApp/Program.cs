using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Collections.Generic;

namespace JWTClientApp
{
    public class Program
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private static readonly string baseUrl = "https://localhost:7239/api/User";

        static void Main(string[] args)
        {
            try
            {
                // Authenticate and get a JWT token from the auth server.
                string token = AuthenticateAndGetToken();
                Console.WriteLine("Token received: " + token);

                // Use the token to perform CRUD operations.
                Console.WriteLine(GetUser(token, "testuser"));  // Get the user with username "testuser".
                Console.WriteLine(CreateUser(token, new CreateUserDto { Username = "newuser", Password = "password", Role = "User" }));
                Console.WriteLine(DeleteUser(token, "newuser"));  // Delete the user with username "newuser".

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        static string AuthenticateAndGetToken()
        {
            string loginUrl = "https://localhost:7239/api/User/login";

            // Request body containing login credentials.
            var loginRequestBody = new { Username = "admin", Password = "password" };
            string requestContentJson = JsonSerializer.Serialize(loginRequestBody);
            StringContent requestContent = new StringContent(requestContentJson, Encoding.UTF8, "application/json");

            // Make a POST request to the login URL.
            HttpResponseMessage response = httpClient.PostAsync(loginUrl, requestContent).Result;

            if (!response.IsSuccessStatusCode)
            {
                // If login fails, read and return the error message.
                string errorContent = response.Content.ReadAsStringAsync().Result;
                return "Login failed: " + errorContent;
            }

            // Read the response content and extract the token.
            string loginResponseContent = response.Content.ReadAsStringAsync().Result;
            JsonElement tokenObject = JsonSerializer.Deserialize<JsonElement>(loginResponseContent);
            return tokenObject.GetProperty("Token").GetString();
        }

        static string GetUser(string token, string username)
        {
            // Set the Authorization header with the received JWT token.
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = httpClient.GetAsync(baseUrl + $"/{username}").Result;
            return ProcessResponse(response, "Get User");
        }

        static string CreateUser(string token, CreateUserDto userDto)
        {
            // Set the Authorization header and make a POST request to create a new user.
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            string userJson = JsonSerializer.Serialize(userDto);
            HttpResponseMessage response = httpClient.PostAsync(baseUrl + "/create", new StringContent(userJson, Encoding.UTF8, "application/json")).Result;
            return ProcessResponse(response, "Create User");
        }

        static string DeleteUser(string token, string username)
        {
            // Set the Authorization header and make a DELETE request to remove the user.
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = httpClient.DeleteAsync(baseUrl + $"/{username}").Result;
            return ProcessResponse(response, "Delete User");
        }

        private static string ProcessResponse(HttpResponseMessage response, string action)
        {
            string responseBody = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                return action + " succeeded: " + responseBody;
            }

            // Handle different HTTP status codes and customize the error message.
            switch (response.StatusCode)
            {
                case HttpStatusCode.Unauthorized:
                    return action + " Failed: Unauthorized - Token may be invalid or expired";
                case HttpStatusCode.Forbidden:
                    return action + " Failed: Forbidden - Insufficient permissions";
                default:
                    return action + " Failed: " + response.StatusCode + " - " + responseBody;
            }
        }
    }

    public class CreateUserDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
