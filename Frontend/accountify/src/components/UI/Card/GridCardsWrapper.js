import React from 'react';
import styles from './GridCardsWrapper.module.scss';

const GridCardsWrapper = props => {
  return <div className={styles.CardsList}>{props.children}</div>;
};

export default GridCardsWrapper;
