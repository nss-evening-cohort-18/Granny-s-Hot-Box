import React from 'react';
import PropTypes from 'prop-types';
import { Link, useHistory } from "react-router-dom"
import { Navbar, NavItem, NavLink } from 'react-bootstrap';


export const Navigation = () => {
const history = useHistory()

    return (
        // potentially switch to NavLink instead of Link

        <div>
            <Navbar>
                <NavItem>
                    <NavLink onClick={() => history.push("/home")}>
                        Home
                    </NavLink>
                </NavItem>
                <NavItem>
                    <NavLink onClick={() => history.push("/test")}>
                        Test
                    </NavLink>
                </NavItem>
                <NavItem>
                    <NavLink onClick={() => history.push("/cart")}>
                        Cart
                    </NavLink>
                </NavItem>
            </Navbar>
        </div>

        /*
        <nav className="nav">
            <Link to='/cocktails'>Cocktails</Link>
            <Link to='/shopping'>Shopping List</Link>
            <Link to='/inventory'>Inventory</Link>
            <Link to='/available'>Available Cocktails</Link>
            <Link to='/changePassword'>Change Password</Link>
        </nav>
        */
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
