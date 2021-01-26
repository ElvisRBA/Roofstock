# SPA Project
The SPA project supports the functionalities for the frontend of the application.

## Installation

Go to the SSL folder and install the server.crt certificate to run the application over HTTPS.

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

## Usage

Run the following commands to start the SPA:

```bash
	npm install
	ng serve
```

## Support
For any questions or comments, please contact me at elvis.rocha@avantica.com
