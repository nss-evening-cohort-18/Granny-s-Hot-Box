import React from "react";
import { Link } from "react-router-dom"


export default function Home() {
    return (
        <div>
            <h1>Granny's Hot Box</h1>
            <Link to="/menu">See the menu</Link>
        </div>
    )
}