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

Sending the request using the 'AWS .NET 8.0 Mock Lambda Test Tool' on localhost
![image](https://github.com/user-attachments/assets/84dfe068-d7d6-4a4f-b4ab-b016bdfc709e)

# Visual Studio setting up AWS Deployment

After setting up your AWS account on Visual Studio. Open  the "Aws Explorer" and create a new Lambda deployment
![image](https://github.com/user-attachments/assets/4686a729-4ef5-418b-9a24-c41369d1fd2a)
![image](https://github.com/user-attachments/assets/eaf0817a-4698-4ae8-824c-898e67c73dff)
![image](https://github.com/user-attachments/assets/ac210bf3-5ee7-4bf7-bca9-16c456fb1a74)

Testing on Visual Studio
![image](https://github.com/user-attachments/assets/9a31f2ca-e247-417d-b321-ba6d96a70d54)

# Setting up AWS Cloud

![image](https://github.com/user-attachments/assets/99285728-10e5-427b-8c6b-0e7d8f8ae52c)
![image](https://github.com/user-attachments/assets/620562ea-2be2-472a-a4fa-751eb8065766)
![image](https://github.com/user-attachments/assets/67257cfd-dfb4-43a8-a6e7-360907b8c118)
![image](https://github.com/user-attachments/assets/b03c83e5-e78a-411b-8a41-08483c0cfe72)


# Unit Tests
![image](https://github.com/user-attachments/assets/88b71de4-612e-46d1-ba04-6df22215d17c)
