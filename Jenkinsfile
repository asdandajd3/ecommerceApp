pipeline {
    agent any

    stages {
        stage('Clone') {
            steps {
                echo 'Cloning source code'
                git branch: 'main', url: 'https://github.com/asdandajd3/ecommerceApp.git'
            }
        }

        stage('Restore Package') {
            steps {
                echo 'Restoring NuGet packages'
                bat 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                cho 'Building project (Release)'
                bat 'cd && echo Current directory && dir'
                bat 'dotnet build ECommerceApp.csproj --configuration Release'
            }
        }

        stage('Tests') {
            steps {
                echo 'Running unit tests'
                bat 'dotnet test --no-build --verbosity normal'
            }
        }

        stage('Publish to temp folder') {
            steps {
                echo 'Publishing project to ./publish'
                bat 'dotnet publish -c Release -o ./publish'
            }
        }

        stage('Copy to running folder') {
            steps {
                echo 'Copying files to C:\\wwwroot\\ecommerceApp'
                bat 'xcopy "%WORKSPACE%\\publish" "C:\\wwwroot\\ecommerceApp" /E /Y /I /R'
            }
        }

        stage('Deploy to IIS') {
            steps {
                echo 'Deploying to IIS'
                powershell '''
                    Import-Module WebAdministration
                    if (-not (Test-Path IIS:\\Sites\\EcommerceAppSite)) {
                        New-Website -Name "EcommerceAppSite" -Port 81 -PhysicalPath "C:\\wwwroot\\ecommerceApp" -ApplicationPool ".NET v4.5"
                    } else {
                        Write-Host "Website EcommerceAppSite already exists"
                    }
                '''
            }
        }
    }
}
