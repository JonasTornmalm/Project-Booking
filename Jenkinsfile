pipeline {
    agent any
     stages {
        stage('Checkout') {
            steps {
                git 'https://github.com/JonasTornmalm/Project-Booking.git'
             }
         }
        stage('Restore Packages') {
            steps {
              bat "dotnet restore"
            }
        }
        stage('Clean') {
       steps {
            bat 'dotnet clean'
       }
       }
       stage('Build') {
         steps {
             bat 'dotnet build "Project Booking.sln"'
         }
       }
       stage('Run') {
            steps {
                bat 'START /B dotnet "Project Booking.dll"'
        }
       }
       stage('robot') {
            steps {
                bat 'robot -d results --variable BROWSER:headlesschrome ProjectBooking.robot'
            }
       }
     }
}