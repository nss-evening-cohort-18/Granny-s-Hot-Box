//FOR TESTING USE
import React, { useState,useEffect } from 'react';

export default function Cart () {
  const [currentCart, setCartList] = useState([]);

  useEffect(() => {
    var requestOptions = {
      method: 'GET',
      redirect: 'follow',
    };
    fetch(
      `https://Localhost:7245/api/MealProduct/2`,
      requestOptions,
    )
      .then((response) => response.json())
      .then(inspectResults);
  }, []);
  const inspectResults = (data) => {
    if (data.length != 0) {
      setCartList(data);
      setMealProductName(data.MealName);
      setMealPrice(data.Price);
      setUserId(data.UserId);
      setImage(data.Image);
      setDescription(data.Description);
      setQuantity(data.Quantity);
      setIsForSale(data.IsForSale);
      setIsDessert(data.IsDessert);
    }
  };



return (
    <div>
    <h1> Granny's Hotbox Cart - Ready to Go!</h1>
    <div>
         {currentCart.map((Meal) => {
            return (
            <>
                <div>
                <Link >${Meal.MealName}</Link>
                </div>

                <div>
                    <li>Quantity</li> <li> ${Meal.Quantity} </li>
                    <li>Meal Price</li> <li>${Meal.Price}</li>
                    
                </div>
                
            </>
            )
         })}
            </div>
      </div>
    );
  }


/*

const setcurrentCarts = (mealProduct) => {
    setcurrentCarts((prev) => {
      let oldCart = { ...prev };
      oldCart.Id = mealProduct;
      return oldCart;
      });
  };
  
  */
