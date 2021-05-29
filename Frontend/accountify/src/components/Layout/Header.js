import React from 'react';

const Header = props => {
  return <header className={props.className}>{props.children}</header>;
};

export default Header;
