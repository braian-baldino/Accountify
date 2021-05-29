import React from 'react';
import logoImg from '../../assets/logo.png';
import classes from './Logo.module.scss';

const Logo = () => {
  return <img className={classes.Logo} src={logoImg} alt="logo.png" />;
};

export default Logo;
