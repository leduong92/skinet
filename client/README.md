# Client

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 12.0.4.

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory.

## Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via a platform of your choice. To use this command, you need to first add a package that implements end-to-end testing capabilities.

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI Overview and Command Reference](https://angular.io/cli) page.


Step 1: Generate a certificate
   Clone the following repository on your local machine and run the generate.sh script in either the terminal or Git Bash. The repository contains all necessary configuration for creating a new trusted certificate.
   https://github.com/RubenVermeulen/generate-trusted-ssl-certificate
   git clone https://github.com/RubenVermeulen/generate-trusted-ssl-certificate.git
   cd generate-trusted-ssl-certificate
   bash generate.sh
   You should now have a server.crt and a server.key file in the repository folder.
Step 2: Install the certificate
   We have to make sure the browser trust our certificate, so we’re going to install it on our local machine.
   OS X
   Double click on the certificate (server.crt)
   Select your desired keychain (login should suffice)
   Add the certificate
   Open Keychain Access if it isn’t already open
   Select the keychain you chose earlier
   You should see the certificate localhost
   Double click on the certificate
   Expand Trust
   Select the option Always Trust in When using this certificate
   Close the certificate window
   The certificate is now installed.
   Windows 10
   Double click on the certificate (server.crt)
   Click on the button “Install Certificate …”
   Select whether you want to store it on user level or on machine level
   Click “Next”
   Select “Place all certificates in the following store”
   Click “Browse”
   Select “Trusted Root Certification Authorities”
   Click “Ok”
   Click “Next”
   Click “Finish”
   If you get a prompt, click “Yes”
   The certificate is now installed.
   Step 3: Configure the application
   Now our certificate is ready to be consumed we have to make sure our application uses the correct certificate.
   Create a folder ssl in the application folder.
   angular-app:
      - e2e
      - src
      - ssl
      .angular-cli.json
   Copy the private key and root certificate from step 1 into the ssl folder. Make sure the file names are like this:
   server.key (private key)
   server.crt (root certificate)
   Before we run our application, make sure you have restarted your browser and updated the start script in package.json.
   "start": "ng serve --ssl true"