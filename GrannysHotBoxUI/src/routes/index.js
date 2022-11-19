// index for router
import React, { useState } from 'react';
import { Redirect, Route, Switch } from 'react-router-dom';
import Authenticated from '../pages/Authenticated';
import LogIn from '../pages/LogIn';
import Test from '../pages/Test';
import Home from '../pages/Home';
import Cart from '../pages/Cart';
import Menu from '../pages/Menu';

export default function Routes({ user }) {
  const [cartItems, setCartItems] = useState([]); 

  console.log(cartItems);
  
  return (
    <div>
      <Switch>
        <Route exact path="/" component={() => <Authenticated user={user} />} />
        <Route exact path="/test" component={() => <Test />} />
        <Route
          exact
          path="/cart"
          component={() => <Cart cartItems={cartItems}  />}
        />
        <Route exact path="/home" component={() => <Home />} />
        <Route
          exact
          path="/menu"
          component={() => (
            <Menu
              setCartItems={setCartItems}
              cartItems={cartItems}              
            />
          )}
        />
        <Route exact path="/login" component={() => <LogIn />} />
        <Route path="*" component={() => <Authenticated user={user} />} />
      </Switch>
    </div>
  );
}
