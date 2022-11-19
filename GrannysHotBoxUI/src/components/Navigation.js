import React from 'react';
import PropTypes from 'prop-types';
//import { Link } from "react-router-dom"
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
    return (
        // potentially switch to NavLink instead of Link
 
        <div>
            <Navbar bg="light">
                <NavbarBrand href="/home">
                    <img
                        className="navbar-logo"
                        src={GrannysHotBoxLogo}
                        alt="Granny's Hot Box Logo"
                    />
                </NavbarBrand>
                <Nav>
                    <Nav.Link href="/home">Home</Nav.Link>
                    <Nav.Link href="/menu">Menu</Nav.Link>
                    <Nav.Link href="/about">About</Nav.Link>
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
                        >{user.displayName}</NavDropdown.Item>
                        <NavDropdown.Divider></NavDropdown.Divider>
                        <Button onClick={signOut}>
                            Sign Out
                        </Button>
                    </NavDropdown>
                </div>
               
 
            </Navbar>
        </div>
 
 
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
