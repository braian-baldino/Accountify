import React from 'react';
import { NavLink } from 'react-router-dom';
import classes from './NavItems.module.scss';

const NavItems = props => {
  return (
    <div className={classes.NavItems}>
      {props.links.map((link, i) => {
        return (
          <NavLink key={i} to={link.path}>
            {link.text}
          </NavLink>
        );
      })}
    </div>
  );
};

export default NavItems;
