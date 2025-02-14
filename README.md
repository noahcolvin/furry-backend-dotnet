# Furry Backend - dotnet
This is a sample backend for a mobile app named `Furry`, a sample mobile app for a pet store. This is not intended to be a complete application, but rather a starting point for a full application.

Created using .NET 9, Web API, and EF Core.

## Features
This has three endpoints:
- `/items`: Get a list of store items
  - By default returns all items
  - `?animal={animal}`: Filter by animal type
  - `?product={product}`: Filter by product type
  - `?search={search}`: Search for items
- `/my-favorite-items`: Get a list of your favorite items
- `/my-friends`: Gets a list of your friends

## How to run
[Install .NET](https://dotnet.microsoft.com/en-us/download) for your platform of choice. You'll also need [Docker Desktop](https://www.docker.com/products/docker-desktop/) to run the database.

#### Edit `appsettings.Development.json` file
`FurryBackend/appsettings.Development.json`: This holds the base URL for the file storage
```
"StorageUrl": "http://{projectId}.supabase.co/storage/v1/object/public"
```

#### Start PostgreSQL
```bash
docker compose up # To keep it running in the terminal

docker compose up -d # To start it in the background
```

#### Run the project
```bash
dotnet run --project FurryBackend/FurryBackend.csproj --launch-profile https
```

## Running Tests
```bash
dotnet test
```

## Questions
#### What is the purpose of this project?
I created this project to demonstrate a simple backend for a mobile app. I made one in TypeScript and had the idea to make one in C# as well.

Here are some others that do more or less the same thing:

- [furry-backend - TypeScript/Deno/Supabase](https://github.com/noahcolvin/furry-backend)
- [furry-backend-express - TypeScript/Node/Express](https://github.com/noahcolvin/furry-backend-express)

#### The controllers are very simple, why don't they do more?
Yes, they only GET a few pieces of data. The sample mobile app is not complete and only displays data. If the modile app ever does more, the backend can be expanded to include the rest of the CRUD operations.

#### Why is the data hard-coded?
Just to keep it simple. In a real application, you'd need a way to add, update, and delete data as well.

#### Why is there no authentication?
No need for the current app.

#### Code X is bad, why didn't you do Y?
This is just a sample exercise and was completed in about a day. I'm sure there are many improvements that could be made. Feel free to make an issue or PR if you have a suggestion. This doesn't need to be perfect but I am certainly open to feedback. I may add to it in the future.
