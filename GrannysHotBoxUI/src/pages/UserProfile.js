import React, {useState} from "react";
import "../styles/main.css"

export default function UserProfile({ user }) {
    return (
      <div className="userPicAndName">
        <img className="UserPic"
          src={user.photoURL}
        />
        <h1 className="usersName">{user.displayName}</h1>
        
      </div>
    )
}
  

//   const [userId, setUserId] = useState([])
//   const [data, setData] = useState([])

//     const getUserById = (event) => {
//         if (event.key === 'Enter') {
//             const Url = `https://localhost:7245/api/User/${userId}`
//             axios.get(Url).then((response) => {
//                 setData(response.data)
//                 console.log(response.data)
//             })
//         }
//     }

//     return (
//         <>

//             <div className="userId">
//                 <input
//                     value={userId}
//                     onChange={event => setUserId(event.target.value)}
//                     onKeyPress={getUserById}
//                     placeholder="Id"
//                     type="text" />
//             </div>

         
//          <h1>UserProfile</h1>
//             <div>
//          <img src={data.image}/>
//             </div>


//         </>
//     )
