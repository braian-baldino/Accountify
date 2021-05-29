import React from 'react';
import Section from '../Layout/Section';
import Dropdown from '../UI/Dropdown';
import InfoItem from '../UI/InfoItem';
import styles from './AnualBalanceBar.module.scss';

const AnualBalanceBar = props => {
  const { selectYearHandler, selectMenuItems, dropdownValue, infoItems } =
    props;
  return (
    <Section>
      <div className={styles.Bar}>
        <Dropdown
          onChange={selectYearHandler}
          id="year-dropdown"
          placeHolder="Año"
          menuItems={selectMenuItems}
          value={dropdownValue}
        />
        <div className={styles.InfoItems}>
          {infoItems &&
            infoItems.map((item, i) => {
              return (
                <InfoItem
                  key={i}
                  className={styles.InfoItem}
                  label={item.label}
                  value={item.value}
                />
              );
            })}
        </div>
      </div>
    </Section>
  );
};

export default AnualBalanceBar;
