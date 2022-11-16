//FOR TESTING USE
import React, { useState,useEffect } from 'react';

export default function Cart ({setMealProductName,setMealPrice,setImage,setDescription,setQuantity,setIsDessert,setIsForSale, setMealPrice}, cartItem) {
  const [currentCart, setCartList] = useState([]);

  useEffect(() => {
    var requestOptions = {
      method: 'GET',
      redirect: 'follow',
    };
    fetch(
      `https://Localhost:7245/api/MealProduct/${cartItem.id}`,
      requestOptions,
    )
      .then((response) => response.json())
      .then(inspectResults);
  }, []);
  const inspectResults = (data) => {   

      setMealProductName(data.MealName);
      setMealPrice(data.Price);
      setUserId(data.UserId);
      setImage(data.Image);
      setDescription(data.Description);
      setQuantity(data.Quantity);
      setIsForSale(data.IsForSale);
      setIsDessert(data.IsDessert);
    
  };



return (
    <div>
    <h1> Granny's Hotbox Cart - Ready to Go!</h1>
    <div>
         {currentCart?.map((Meal) => {
            return (
            <>
                <div>
                <h1 >${Meal.MealName}</h1>
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
