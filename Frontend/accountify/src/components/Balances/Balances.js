import React, { useState, useEffect } from 'react';
import Section from '../Layout/Section';
import AddNew from '../UI/AddNew';
import DataCard from '../UI/Card/DataCard';
import mockData from '../../dummy/AnualBalances';
import GridCardsWrapper from '../UI/Card/GridCardsWrapper';
import Dropdown from '../UI/Dropdown';
import RadioButtons from '../UI/RadioButtons';
import styles from './Balances.module.scss';
import AnualBalanceBar from '../AnualBalances/AnualBalanceBar';
import axios from 'axios';

const labels = ['Ingresos', 'Egresos', 'Balance'];
const keys = ['totalIncomesResult', 'totalSpendingsResult', 'result'];
const headerKey = 'month';
const selectMenuItems = [
  { label: '2021', value: 2021 },
  { label: '2020', value: 2020 },
  { label: '2019', value: 2019 },
  { label: '2018', value: 2018 },
  { label: '2017', value: 2017 },
];
const radioItems = [
  { label: 'Positivos', value: 'true' },
  { label: 'Negativos', value: 'false' },
  { label: 'Todos', value: 'all' },
];

const mapData = data => {
  return data.map(object => {
    let monthString = '';
    switch (object.month) {
      case 1:
        monthString = 'Enero';
        break;
      case 2:
        monthString = 'Febrero';
        break;
      case 3:
        monthString = 'Marzo';
        break;
      case 4:
        monthString = 'Abril';
        break;
      case 5:
        monthString = 'Mayo';
        break;
      case 6:
        monthString = 'Junio';
        break;
      case 7:
        monthString = 'Julio';
        break;
      case 8:
        monthString = 'Agosto';
        break;
      case 9:
        monthString = 'Septiembre';
        break;
      case 10:
        monthString = 'Octubre';
        break;
      case 11:
        monthString = 'Noviembre';
        break;
      case 12:
        monthString = 'Diciembre';
        break;
      default:
        monthString = '';
        break;
    }
    return {
      id: object.id,
      month: monthString,
      positive: object.positive,
      totalIncomesResult: '$' + object.totalIncomesResult,
      totalSpendingsResult: '$' + object.totalSpendingsResult,
      result: '$' + object.result,
    };
  });
};

const mapYearInfo = anualBalance => {
  let savingsPesos = 0;
  let savingsUsd = 0;
  let result = 0;

  anualBalance.map(element => {
    console.log('mapYearInfo',element);
    savingsPesos = element.savings.amount??0;
    result = element.result;
  });

  return [
    { label: 'Ahorros $', value: '$' + savingsPesos },
    { label: 'Ahorros USD', value: '$' + savingsUsd },
    { label: 'Balance', value: '$' + result },
  ];
};

const selectedAnualBalance = (data, year) => {
  return data.filter(anualBalance => anualBalance.year === year);
};

const Balances = props => {
  const [data, setData] = useState();
  const [balances, setBalances] = useState();
  const [selectValues, setSelectValues] = useState();
  const [dropdownValue, setDropdownValue] = useState(new Date().getFullYear());

  useEffect(() => {
    if (!data) {
      axios
        .get('https://localhost:5001/api/anualBalance')
        .then(res => setData(res.data));
    }

    if (data) {
      const availableYears = data.map(anual => {
        return { label: anual.year.toString(), value: anual.year };
      });
      setSelectValues(availableYears);

      const filteredAnual = selectedAnualBalance(data, dropdownValue);
      const selectedBalances = filteredAnual.map(anual => anual.balances);
      setBalances(...selectedBalances);
    }
  }, [dropdownValue]);

  const handleDrodownChange = event => {
    setDropdownValue(event.target.value);
  };

  const anualBalance = data && selectedAnualBalance(data, dropdownValue);
  const anualInfo = anualBalance && mapYearInfo(anualBalance);
  const mappedData = balances && mapData(balances);

  return (
    <Section>
      <AnualBalanceBar
        selectMenuItems={selectMenuItems}
        dropdownValue={dropdownValue}
        selectYearHandler={handleDrodownChange}
        infoItems={anualInfo}
      />
      <GridCardsWrapper>
        {mappedData &&
          mappedData.map((balance, i) => {
            return (
              <DataCard
                key={i}
                object={balance}
                headerKey={headerKey}
                labels={labels}
                keys={keys}
              />
            );
          })}
      </GridCardsWrapper>
      <AddNew />
    </Section>
  );
};

export default Balances;
