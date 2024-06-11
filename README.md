# Ticketing App
 
This is a ticketing app for the **CleverPoint assignment** 
that represents a backend solution for an **internal ticketing system**.

## Stack
> - ASP.NET Core 8
> - .NET 8 SDK
> - Entity Framework Core as ORM
> - Postgres as the DB choice
> - MediatR as a package for handling the CQRS pattern

## Design Decisions
> This project represents a modular monolith, following the Clean Architecture principles,
while using the CQRS pattern to handle the operations.
For simplicity and because there was not much complexity on db side, a code first approach
was followed for the db creation the models and migrations.
This approach leaves room for scaling and migration into a microservice environment,
because it tries to keep the concerns seperated. This is also an improvement that can be made in the future.

> Most of the logic was implemented inside the command and query handlers on the application level.

> To ensure some security a concept of JWT Bearer authorization was implemented for the users.

> Docker compose was used so that all the services are contained and orchestrated to some extend.
PgAdmin was included in the composition to be able to check the DB at any time without the need for installation


## Models
> Three models were created for this assignment. The User, Shipment and Ticket models.

>> ### User
>>> This model was to enable the representation of users from different departments that would
assign and receive tickets. Each user has the tickets assigned to the user, as well as the tickets the user created.
There is no endpoint for user creation because they are seeded, which simulates the user creation from an external system,
because I think it should not be the concern of the current system.

>> ### Shipment
>>> Represents the package that has been shipped and can be carrier agnostic, 
and keep track of most of the important statuses. 
There is also a composite index ensuring that the tracking number
is unique for a specific carrier.
A good improvement for that entity would be to be able to track every status update that has been made,
made to ensure the shipment situation and enhance the service quality insights.

>> ### Ticket
>>> This is the core model of the system that binds together all the other entities.
It has a user that creates it and a user that it is assigned to. There is also a relationship to
a specific shipment. The goal is to be able to provide info on the ticket itself along with info about the shipment it refers to.
A future improvement would be to make ticket statuses, so that the procedure is more robust for the task.
Also a notification service would benefit the assignee and the creator to be able to get notifies when a ticket is assigned to you,
as well as being notified for the status changes made on a ticket. Also if the business demands it,
a logic based on account type (e.g. operations), so tha specific account types can create tickets or
get assigned one, would ensure ticket integrity and minimize the noise in the system.