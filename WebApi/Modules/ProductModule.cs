using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using Application.Products.Create;
using Application.Products.Get;
using Carter;
using Domain.Core.Abstractions.Maybes;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace WebApi.Modules
{
    /// <summary>
    /// Defines product api routes.
    /// </summary>
    public class ProductModule : CarterModule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductModule"/> class.
        /// </summary>
        public ProductModule()
            : base("/products")
        {
        }

        /// <inheritdoc/>
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/", async (CreateProductCommand request, ISender sender) =>
            {
                var id = await sender.Send(request);
                return Results.Ok(id);
            });
            app.MapGet("/{id}", async (Guid id, ISender sender) =>
                await Maybe<GetProductQuery>.From(new GetProductQuery(id))
                    .Bind(command => sender.Send(command))
                    .Match(Results.Ok, Results.NotFound));
        }
    }
}
