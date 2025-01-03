﻿using MediatR;
using Restaurants.Application.Dishes.Dtos;
using System.Collections.Generic;

namespace Restaurants.Application.Dishes.Queries.GetDishesForRestaurant
{
    public class GetDishesForRestaurantQuery : IRequest<IEnumerable<DishDto>>
    {
        public int RestaurantId { get; }

        public GetDishesForRestaurantQuery(int restaurantId)
        {
            RestaurantId = restaurantId;
        }
    }
}
