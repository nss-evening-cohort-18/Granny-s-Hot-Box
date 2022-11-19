import React, { useEffect, useState } from 'react';
import { getAllMealProducts } from '../ApiManager';
import '../styles/menu.css';
//import { FontAwesomeIcon} from ''

export default function Menu({ setCartItems, cartItems }) {
  const [mealProducts, setMealProducts] = useState([]);

  useEffect(() => {
    getAllMealProducts().then((product) => {
      setMealProducts(product);
    });
  }, []);

  const checkAndAddToCart = (product) => {
    const MPExist = cartItems.find((item) => item.id === product.id);
    if (MPExist) {
        
      setCartItems((prev) => {
        const index = prev.findIndex((item) => item.id === product.id);
        prev[index].cartQuantity++
        return [...prev]
      })
     
    } else {
      setCartItems((prev) => [...prev, { ...product, cartQuantity: 1 }]);
    }
  };

    return (
    <>
      <h1>Menu</h1>
      <div className="menu-items"><br></br>
        <div>
          {mealProducts.map((product) => {
            return (
              <div className="single-menu-item" key={product.id}>
                <img className="menu-image" src={product.image} />
                <h5>{product.mealName}</h5>
                <h6>{product.price}</h6>
                <button onClick={() => checkAndAddToCart(product)} >
               {''}
               Add to Cart
               {''}
                </button>                
                <button onClick={() => alert(product.description)}>
                  Description
                </button>
              </div>
            );
          })}
        </div>
      </div>
    </>
    
  );
}
