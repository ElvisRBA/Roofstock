# Download Projects
You can dowload the projects as ZIP file, just click on the green button "Code" and then click on "Download ZIP"
# API Project
The API project supports the functionalities for the backend of the application.

## Requirements
- .NET Core >= 3.1.301
- DB Browser for SQLite (in case you want to inspect the "roofstock.db" database inside the API folder)

## Installation

In a new cmd console navigate to the API Project and run the following commands to start the API.

```bash
dotnet dev-certs https --trust (Click yes to install the certificate on the popup window shown)
dotnet restore
dotnet build
dotnet watch run
```

After the API project has started, the database is auto-generated and you can follow with the client project steps (Please do not close the API cmd console)

# Client Project
The client project supports the functionalities for the frontend of the application.

## Requirements
- npm >= 6.10.3
- node >= 12.10.0
- Angular CLI >= 10.1.3

## Installation

Go to the SSL folder inside the Client Project and install the server.crt certificate to run the application over HTTPS.

Follow the instructions below:

**OS X**

```bash
	1. Double click on the certificate (server.crt).
	2. Select your desired keychain (login should suffice).
	3. Add the certificate.
	4. Open Keychain Access if it isn’t already open.
	5. Select the keychain you chose earlier.
	6. You should see the certificate localhost.
	7. Double click on the certificate.
	8. Expand Trust.
	9. Select the option Always Trust in When using this certificate.
	10. Close the certificate window.

	The certificate is now installed.
```

**Windows 10**

```bash
	1. Double click on the certificate (server.crt).
	2. Click on the button “Install Certificate …”.
	3. Select whether you want to store it on the user level or on the machine level.
	4. Click “Next”.
	5. Select “Place all certificates in the following store”.
	6. Click “Browse”.
	7. Select “Trusted Root Certification Authorities”.
	8. Click “Ok”.
	9. Click “Next”.
	10. Click “Finish”.

	If you get a prompt, click “Yes”.
```

In a new cmd console navigate to the Client Project and run the following commands to start the client application:

```bash
npm install
ng serve
```

After you have run the client application open your browser and enter the URL: https://localhost:4200 (Please do not close the Client cmd console)

## Support
For any questions or comments, please contact me at elvis.rocha@avantica.com