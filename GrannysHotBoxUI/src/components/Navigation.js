import React from 'react';
import PropTypes from 'prop-types';
import { Link, useHistory } from "react-router-dom"
import { signOut } from '../utils/auth';
import GrannysHotBoxLogo from "../Images/GrannysHotBoxLogo";
import {
    Navbar,
    Button,
    NavbarBrand,
    NavDropdown,
    Nav
 } from 'react-bootstrap';
 
 
export const Navigation = ({ user }) => {
const history = useHistory()
    return (
        // potentially switch to NavLink instead of Link
 
        <div>
            <Navbar  bg="light">
             <NavbarBrand href="/home">
                    <img
                        className="navbar-logo"
                        src={GrannysHotBoxLogo}
                        alt="Granny's Hot Box Logo"
                    />
                </NavbarBrand>
               <Nav>
                    <Nav.Link onClick={() => history.push("/Home")">Home</Nav.Link>
                    <Nav.Link onClick={() => history.push("/Menu")">Menu</Nav.Link>
                    <Nav.Link onClick={() => history.push("/Cart")"">Cart</Nav.Link>
                </Nav>
                     <div className='user-dropdown'>
                    <img
                        href="/home"
                        className="profilePic"
                        src={user.photoURL}
                    ></img>
                    <NavDropdown>
                        <NavDropdown.Item
                            eventKey="1"
                            href="/userProfile"
                        >{user.displayName}</NavDropdown.Item>
                        <NavDropdown.Divider></NavDropdown.Divider>
                        <Button onClick={signOut}>
                            Sign Out
                        </Button>
                    </NavDropdown>
                </div>
                </Navbar>

           
 
    );
}
 
 
 
Navigation.defaultProps = {
    user: null,
};
 
Navigation.propTypes = {
    user: PropTypes.oneOfType([
        PropTypes.bool,
        PropTypes.shape({
            name: PropTypes.string,
            image: PropTypes.string,
            uid: PropTypes.string,
            user: PropTypes.string,
        }),
    ]),
}
