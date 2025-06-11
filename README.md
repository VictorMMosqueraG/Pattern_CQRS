# Pattern CQRS

The pupose of this repository is to demonstrate the structure and funcionality of the CQRS pattern in .NET.

To set up run this project, follow these steps:

## Table of Contents
- [Backend Setup and Dependencies](#backend-setup-and-dependencies)
- [Environment](#environments)

## Environments
For this project it is using environments dev, stage and prod, copy a data from `appsettings.json` and create new file with the name `appsettings.Development.json`, `appsettings.Stagement.json` or `appsettings.Production.json`

## Backend Setup and Dependencies
1. **Docker Setup**: Ensure that docker is installed on your system. Docker will be used to manage database container for the development environment. If yo don't have Docker installed, you can download and install it from the docker website.

2. **Clone Repository**: Clone this project repository to your local machine using Git. You can do this by running the following command in your terminal:

    ```
    https://github.com/VictorMMosqueraG/Pattern_CQRS.git
    ```
3. **Install SDK**: You must intall SDK 9, wicht to date is the one used in this repository.

4. **Database Setup (Development Environment)**: Run database with Docker: In the development environment, the databse is manage using Docker (Point 1). To start the database container, run the following command:

    ```
    docker-compose up -d
    ```

    This command is a one-time operation dedicate to creating the necessary image and container, When you wish to halt the testing, simply terminate the container using the provided command. When needed again, restart the container using the same specific command. This approach ensure a streamlined and convenient database management process.

- View Running Containers: To see a list of runnign Docker containers, use the following command:

    ```
    docker ps
    ```

- Start or Stop Containers: To start a stopped container, use:

    ```
    docker start "container-name"
    ```

- To stop a running container, use:

    ```
    docker stop "container-name"
    ```

5. **Running project**: Then, after following the last steps, can you run this project using the following commnad:

    ```
    dotnet run
    ```
