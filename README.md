<p align="center">
  <a href="https://github.com/berkerertan/Tobeto3A-NArchitecture.BootcampProject/graphs/contributors"><img src="https://img.shields.io/github/contributors/berkerertan/Tobeto3A-NArchitecture.BootcampProject.svg?style=for-the-badge"></a>
  <a href="https://github.com/berkerertan/Tobeto3A-NArchitecture.BootcampProject/network/members"><img src="https://img.shields.io/github/forks/berkerertan/Tobeto3A-NArchitecture.BootcampProject.svg?style=for-the-badge"></a>
  <a href="https://github.com/berkerertan/Tobeto3A-NArchitecture.BootcampProject/stargazers"><img src="https://img.shields.io/github/stars/berkerertan/Tobeto3A-NArchitecture.BootcampProject.svg?style=for-the-badge"></a>
  <a href="https://github.com/berkerertan/Tobeto3A-NArchitecture.BootcampProject/issues"><img src="https://img.shields.io/github/issues/berkerertan/Tobeto3A-NArchitecture.BootcampProject.svg?style=for-the-badge"></a>
  <a href="https://github.com/berkerertan/Tobeto3A-NArchitecture.BootcampProject/blob/master/LICENSE"><img src="https://img.shields.io/github/license/berkerertan/Tobeto3A-NArchitecture.BootcampProject.svg?style=for-the-badge"></a>
</p><br />

# CodeStorm Educational Platform Backend API (.NET)

## Project Description

This project provides the backend API for the CodeStorm Educational Platform. It is developed based on Clean Architecture principles and designed using nArchitectureGen. The project offers a high-performance and scalable structure.

## Features
<table>
  <tr>
    <td>- Clean Architecture</td>
    <td>- CQRS (Command Query Responsibility Segregation)</td>
  </tr>
  <tr>
    <td>- Advanced Repository Pattern</td>
    <td>- Role-Based Access Control (Instructor, Student, Admin)</td>
  </tr>
  <tr>
    <td>- Dynamic Query</td>
    <td>- Pagination</td>
  </tr>
  <tr>
    <td>- OTP (One-Time Password)</td>
    <td>- Authentication with JWT</td>
  </tr>
  <tr>
    <td>- Logging with Serilog</td>
    <td>- PDF Generation (Certificate)</td>
  </tr>
  <tr>
    <td>- Cloudinary Media Service</td>
    <td>- Global Exception Handling</td>
  </tr>
  <tr>
    <td>- MsSQL</td>
    <td>- Refresh Token and Token Renewal</td>
  </tr>
  <tr>
    <td>- Token Revocation</td>
    <td>- Mail Service</td>
  </tr>
   <tr>
    <td>- Mediatr</td>
    <td></td>
  </tr>
</table>

## Architecture
This project adopts Clean Architecture and CQRS (Command Query Responsibility Segregation) principles. This architectural structure ensures the project is modular, testable, and maintainable. Mediatr is used in the implementation of the CQRS pattern.

## File Structure
<p float="left">
  <img src="https://i.imgur.com/YyxiUPq.png" alt="Project Image 1" width="500"/>
</p>

## 💻 About nArchitectureGen
<p align="center">
  <a href="https://github.com/kodlamaio-projects/nArchitecture"><img src="https://user-images.githubusercontent.com/53148314/194872467-827dc967-acee-4bca-88a2-59ed5695bebf.png" height="75"></a>
  <h3 align="center">nArchitectureGen
</h3>
Developed inspired by Clean Architecture, nArchitecture is a monolithic project showcasing advanced development techniques. The project includes Clean Architecture, CQRS, Advanced Repository, Dynamic Querying, JWT, OTP, Google and Microsoft Authentication, Role-Based Management, Distributed Caching (Redis), Logging (Serilog), Elastic Search, Code Generator, and more.

## Usage
API Documentation
You can use Swagger UI for all API endpoints and details used in the project.

## Features
Clean Architecture
This project applies Clean Architecture principles to provide a modular, testable, and maintainable structure. It minimizes dependencies between layers and makes business logic independent of the UI, database, or other external dependencies.

## CQRS (Command Query Responsibility Segregation)
CQRS separates commands (data modification operations) and queries (data reading operations). This improves performance optimization and better data integrity.

## Authentication with JWT
<p float="left">
  <img src="https://i.imgur.com/fMvXXyO.png" alt="Project Image 1" width="370"/>
</p>
Authentication is performed using JWT (JSON Web Token). This offers a secure and stateless authentication method. The JWT Payload decode part is as shown in the image.

## OTP (One-Time Password)
We provide an extra layer of security by using one-time passwords to verify user identities.

## Logging with Serilog
<p float="left">
  <img src="https://i.imgur.com/GSNMuIF.png" alt="Project Image 1" width="240"/>
</p>
Using Serilog, logs in the application are configured and recorded. This is very useful for debugging and monitoring the application. In the current demo, log records are stored as text files, and the infrastructure for MongoDB usage is available.

## Dynamic Query
Dynamic querying capabilities allow flexible and customizable queries according to the needs of the user or the application.

## Global Exception Handling
Global exception handling manages errors centrally by capturing them at a single point, regardless of where they occur in the application. This provides more consistent error messages and a better user experience.

## Refresh Token and Token Renewal
<p float="left">
  <img src="https://i.imgur.com/rgxDMz5.png" alt="Project Image 1" width="650"/>
</p>
Using refresh tokens, we extend user session durations, so users do not need to log in again. When a user logs out or in case of a security breach, the token is revoked, blocking access. RefreshToken is created as HttpOnly Cookie when the user logs in. HttpOnly type allows this cookie to be carried only with http requests.

## Token Revocation
Token revocation allows users to manually end their sessions or block access in case of security breaches. This is an important feature that enhances application security.

## PDF Generation (Certificate)
<p float="left">
  <img src="https://i.imgur.com/XVNCUgM.png" alt="Project Image 1" width="300"/>
  <img src="https://i.imgur.com/uriLTyr.png" alt="Project Image 2" width="200"/>
</p>
In our project, we use the iTextSharp library to generate certificates when users complete their training. This library allows us to dynamically create and edit PDF files. It enables users to create documents like course completion certificates in PDF format. This provides users with a tangible indicator of achievement and enhances the platform's professionalism.

## Mail Service
<p float="left">
  <img src="https://i.imgur.com/YI98iYV.png" alt="Project Image 1" width="370"/>
</p>
We use the MailKit library and Gmail's SMTP server to send emails to users. This structure provides a reliable and flexible solution for performing actions such as email verification and password reset. Emails are sent for various operations (password reset, account verification, two-factor authentication), enhancing user experience and security. Mail bodies are stored as HTML files, and when a mail is sent, the appropriate link or one-time code field in the file is filled out and sent.

## Database Schema and Request-Response Body Examples
<table>
  <!-- row 1 -->
  <tr>
    <td colspan="3" align="center">
      <img src="https://i.imgur.com/WFJIROU.png" alt="default-header" width="900"/><br>
      <code>Database Diagram</code>
    </td>
  </tr>
  <!-- row 2 -->
  <tr>
    <td align="center">
      <img src="https://i.imgur.com/qIPlDzW.png" alt="cloud-db-logo" width="300"/><br>
      <code>Response on Successful Login</code>
    </td>
    <td align="center">
      <img src="https://i.imgur.com/0x5Ibhi.png" alt="cloud-db-logo" width="300"/><br>
      <code>Login Request</code>
    </td>
    <td align="center">
      <img src="https://i.imgur.com/V9acTLn.png" alt="gradient-markdown-logo" width="300"/><br>
      <code>Generated Certificates</code>
    </td>
  </tr>
  <!-- row 3 -->
  <tr>
    <td align="center">
      <img src="https://i.imgur.com/LaE9tu3.png" alt="custom-logo" width="300"/><br>
      <code>Response on Error</code>
    </td>
    <td align="center">
      <img src="https://i.imgur.com/NB66lcs.png" alt="skills-light" width="300"/><br>
      <code>Student Registration Schema</code>
    </td>
    <td align="center">
      <img src="https://i.imgur.com/PT8pBDT.png" alt="gradient-markdown-logo" width="300"/><br>
      <code>Command Request</code>
    </td>
  </tr>
  <tr>
  <!-- row 4 -->
    <td align="center">
      <img src="https://i.imgur.com/ubNu8Gl.png" alt="readme-ai-header" width="300"/><br>
      <code>Training Creation Schema</code>
    </td>
    <td align="center">
      <img src="https://i.imgur.com/D30SOJG.png" alt="black-logo" width="300"/><br>
      <code>Certificate Creation Schema</code>
    </td>
    <td align="center">
      <img src="https://i.imgur.com/tyQXhD9.png" alt="gradient-markdown-logo" width="300"/><br>
      <code>Chapter Request</code>
    </td>
  </tr>
</table>

## Contribution Guide
If you want to contribute to this project, please follow the steps below:

- Fork the repository.
- Create a new branch: git checkout -b my-new-feature
- Commit your changes: git commit -am 'Add some feature'
- Push to the branch: git push origin my-new-feature
- Create a Pull Request.

## Contact
If you have any questions or feedback about this project, please contact us here.

# Thank you
