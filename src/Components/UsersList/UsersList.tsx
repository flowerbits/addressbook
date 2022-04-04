import React from "react";

type UserType = {
  id: string;
  name: string;
  phoneNumber: string;
};

type UsersType = {
  data: UserType[];
  onDelete: (id: string) => void;
};

export const UsersList: React.FC<UsersType> = ({
  data,
  onDelete,
}: UsersType) => {
  return (
    <ul>
      {data.map((user) => (
        <div>
          <li key={user.id} onClick={() => onDelete(user.id)}>
            <span>{user.name}</span>
            <span>{user.phoneNumber}</span>
          </li>
        </div>
      ))}
    </ul>
  );
};
