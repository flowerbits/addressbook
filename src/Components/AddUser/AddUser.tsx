import React, { useState } from "react";

export const AddUser = (props) => {
  const [name, setName] = useState("");
  const [phoneNumber, setPhoneNumber] = useState("");

  const submitHandler = (e: any) => {
    e.preventDefault;
    props.onAdd({ name: name, phoneNumber: phoneNumber });
  };

  return (
    <diV>
      <form onSubmit={submitHandler}>
        <div>
          <label htmlFor='name'>
            <input
              type='text'
              id='name'
              value={name}
              onChange={(e) => setName(e.target.value)}
            ></input>
          </label>
        </div>
        <div>
          <label htmlFor='phoneNumber'>
            <input
              type='text'
              id='phoneNumber'
              value={phoneNumber}
              onChange={(e) => setPhoneNumber(e.target.value)}
            ></input>
          </label>
        </div>
        <button type='submit'>Add new User</button>
      </form>
    </diV>
  );
};
