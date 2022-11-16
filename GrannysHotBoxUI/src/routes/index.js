// index for router
import React from 'react';
import { Route, Switch } from 'react-router-dom';
import Authenticated from '../pages/Authenticated';
import LogIn from '../pages/LogIn';
import Test from '../pages/Test';
import Home from '../pages/Home';
import About from '../pages/About';
import Menu from '../pages/Menu';

export default function Routes({ user }) {
  return (
    <div>
      <Switch>
        <Route exact path="/" component={() => <Authenticated user={user} />} />
        <Route exact path="/test" component={() => <Test /> } />
        <Route exact path="/about" component={() => <About /> } />
        <Route exact path="/home" component={() => <Home />} />
        <Route exact path="/menu" component={() => <Menu />} />
        
        <Route exact path="/login" component={() => <LogIn />} />
        <Route path="*" component={() => <Authenticated user={user} />} />
      </Switch>
    </div>

  );
}
