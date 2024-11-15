# About
This project demonstrates the use of Lambda AWS with various triggers: Timer Trigger, HTTP Trigger, MySQL Changes Trigger, and MySQL Select.

# Stacks of this project
- .NET 8
- AWS Lambda
- MySQL
- Postman (for API testing)
- Visual Studio 2022

# Http Trigger
```csharp
public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}
````
Main method
![image](https://github.com/user-attachments/assets/4d8827e5-daad-4b26-b21e-70f689120f90)

Sending a request using the AWS Mock screen
![image](https://github.com/user-attachments/assets/84dfe068-d7d6-4a4f-b4ab-b016bdfc709e)
