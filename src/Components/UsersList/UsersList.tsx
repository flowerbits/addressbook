import React from "react";

type UserType = {
  id: string;
  name: string;
  phoneNumber: string;
};

type UsersType = {
  data: UserType[];
};

export const UsersList: React.FC<UsersType> = ({ data }: UsersType) => {
  return (
    <ul>
      {data.map((user) => (
        <div>
          <li key={user.id} onClick={() => {}}>
            <span>{user.name}</span>
            <span>{user.phoneNumber}</span>
          </li>
        </div>
      ))}
    </ul>
  );
};
