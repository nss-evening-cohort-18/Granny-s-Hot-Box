import React, {useEffect, useState} from "react";
import {getAllMealProducts} from '../ApiManager';
import '../styles/menu.css' 


export default function Menu() {
  const [mealProducts, setMealProducts] = useState([])

   useEffect(
    () => {
        getAllMealProducts()
            .then((product) => {
                setMealProducts(product)
             
            })

    },
    [])
   
   
    return (
        <>
        <h1>Menu</h1>
        <div className='menu-items'>{mealProducts.map((product) => {
            return <div className='single-menu-item' key={product.id}>
                    <img className='menu-image' src={product.image}/>
                    <h5>{product.mealName}</h5>
                    <h6>{product.price}</h6>
                   </div>
                })}
        </div>
        </>
    )
}