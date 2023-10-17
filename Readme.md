# Aeroqual C# Cloud Developer Test

## Objectives
This test is to create a simple API that serves data from a JSON file. We would like to see what you would consider production quality code.

## Instructions
- The JSON file is `data.json`, and contains a list of people, with their names and ages.
- We would like you to create a RESTful API that allows you to create, update, delete, and get people.
- In addition, we would like to be able to search by a person's name. The input may not always be a complete name, e.g. if the input is `hat`, we expect `hat`, `hatter`, `that` etc to be returned.
- You are free to layout the project however you wish. 

## Submitting Completed Test
- Please commit your code to a private github repository, and invite both `AeroqualHayden` and `maxgruebneraeroqual` as collaborators.
- If you cannot do that for some reason, please zip the source code and email it to the recruiter.

## Design decisions
_If you have made any design decisions that you would like to explain, please add them here_
- Decided to separate the Services from the Api so that it is more modular/reusable
- Added the ApiContracts/Dtos to a separate project so that they can potentially be used as nuget packages.
- Have Cancellation tokens passed down from the Controller through to the repository out of habit, even though the nuget package I am using to modify the JSON file doesn't support cancelling actions.
- Added validation to a number of service methods, and pagination to the GetAll method because why not?
- Would have written integration tests, but I ended up messing around for far too long figuring out an issue with the JSON data store (and I've got my life to live).
- Added extension methods to register the data access and application service layer, to keep logic nicely bundled away and to prevent files from bloating.