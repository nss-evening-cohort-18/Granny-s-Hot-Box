//FOR TESTING USE
import React, { useEffect, useState } from 'react';
import '../styles/menu.css';

export default function Cart({ cartItems, setCartItems }) {
  const [Total, addToTotal] = useState(0.0);

  let runningTotal = 0.0;

  const calculateTotal = () => {
    cartItems.map((item) => {
      let productTotal = item.price * item.cartQuantity;
      runningTotal += productTotal;
      addToTotal(runningTotal);
    });
  };

  const DeleteItemFromCart = (productToDelete) => {
    cartItems.map((product) => {
      if (product.id === productToDelete.id) {
        product.cartQuantity--;
        calculateTotal();
      }
    });
  };

  useEffect(() => {
    calculateTotal();
  }),
    [];

  console.log(cartItems);
  console.log(Total);

  //method to loop through cartItems and calculate== set the total to state
  // delete method should loop through and remove items and recalculate total

  return (
    <div>
      <h1> Granny's Hotbox Cart - Ready to Go!</h1>
      <div className="menu-items">
        {cartItems.map((item) => {
          return (
            <div key={item.id} className="single-menu-item">
              <div>
                <h1>{item.mealName}</h1>
              </div>

              <div>
                <img className="menu-image" src={item.image}></img>
                <p>Quantity: {item.cartQuantity} </p>
                <p>Meal Price: {item.price}</p>
                <button onClick={() => DeleteItemFromCart(item)}>Delete</button>
              </div>
            </div>
          );
        })}
      </div>
      <p>Order Total: ${Total}</p>
    </div>
  );
}
