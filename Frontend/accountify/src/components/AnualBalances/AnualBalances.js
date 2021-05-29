import React, { useState } from 'react';
import { Route } from 'react-router-dom';
import Section from '../Layout/Section';
import mockData from '../../dummy/AnualBalances';
import DataCard from '../UI/Card/DataCard';
import AddNew from '../UI/AddNew';
import GridCardsWrapper from '../UI/Card/GridCardsWrapper';
import Balances from '../Balances/Balances';
import * as pathConstants from '../../constants/routePaths';

const labels = ['Ahorros $', 'Ahorros USD', 'Balance'];
const keys = ['pesosSavings', 'usdSavings', 'result'];
const headerKey = 'year';

const mapData = data => {
  return data.map(object => {
    return {
      id: object.id,
      year: object.year,
      positive: object.positive,
      pesosSavings: `$${object.savings[0]['amount']}`,
      usdSavings: `$${object.savings[1]['amount']}`,
      result: '$' + object.result,
    };
  });
};

const AnualBalances = () => {
  const [anualBalances, setAnualBalances] = useState(mockData);

  const mappedData = mapData(anualBalances);

  return (
    <Section>
      <GridCardsWrapper>
        {mappedData.map((anualBalance, i) => {
          return (
            <DataCard
              key={i}
              object={anualBalance}
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

export default AnualBalances;
