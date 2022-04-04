import React, { useState, useEffect } from "react";
import { UsersList } from "../UsersList/UsersList";
import { AddUser } from "../AddUser/AddUser";

import "./styles.scss";

// POST: http://localhost:5000/address
// GET ALL : http://localhost:5000/address
// GET BY ID: http://localhost:5000/address/guid
// DELETE: http://localhost:5000/address/guid

export const Users = (props) => {
  const [users, setUsers] = useState([]);

  useEffect(() => {
    fetch("http://localhost:5000/address")
      .then((response) => response.json())
      .then((responseData) => {
        const loadedUsers = [];
        for (let key in responseData) {
          loadedUsers.push({
            id: key,
            name: responseData[key].name,
            phoneNumber: responseData[key].phoneNumber,
          });
        }
        setUsers(loadedUsers);
      });
  }, []);

  const addUser = (user) => {
    const response = fetch("http://localhost:5000/address", {
      method: "POST",
      body: JSON.stringify(user),
      headers: { "Content-Type": "application/json" },
    })
      .then((response) => {
        return response.json();
      })
      .then((responseData) => {
        setUsers((prevUser) => [
          ...prevUser,
          {
            name: responseData.name,
            phoneNumber: responseData.phoneNumber,
            ...user,
          },
        ]);
      });
  };

  const onDeleteHandler = (id: string) => {
    const updateUsers = users.filter((item: { id: string }) => item.id !== id);
    setUsers(updateUsers);
  };

  return (
    <section>
      <UsersList data={users} onDelete={onDeleteHandler} />
      <AddUser onAdd={addUser} />
    </section>
  );
};
