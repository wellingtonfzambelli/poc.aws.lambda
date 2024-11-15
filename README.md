# About
This project demonstrates the use of Lambda AWS with various triggers: Timer Trigger, HTTP Trigger, MySQL Changes Trigger, and MySQL Select.

# Stacks of this project
- .NET 8
- AWS Lambda
- XUnit
- Visual Studio 2022

# Http Trigger
Main method
![image](https://github.com/user-attachments/assets/9de8d8d5-d5d7-45a6-9476-bdb39b73ca5d)

Json used to send the request
```json
{
    "resource": "/{proxy+}",
    "path": "/",
    "httpMethod": "GET",
    "queryStringParameters": {
        "name": "John"
    },
    "headers": {
        "Content-Type": "application/json"
    },
    "body": null,
    "isBase64Encoded": false
}
````

Sending the request using the AWS Mock screen
![image](https://github.com/user-attachments/assets/84dfe068-d7d6-4a4f-b4ab-b016bdfc709e)

# Testing
![image](https://github.com/user-attachments/assets/88b71de4-612e-46d1-ba04-6df22215d17c)
