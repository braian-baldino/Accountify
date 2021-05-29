import React, { Fragment } from 'react';
import { Route } from 'react-router-dom';
import * as pathConstants from '../../constants/routePaths';
import Balances from '../Balances/Balances';

const NavRouters = () => {
  return (
    <Fragment>
      <Route path={pathConstants.BALANCES_PATH} component={Balances} />
      <Route path={pathConstants.VEHICLES_PATH} />
      <Route path={pathConstants.STATISTICS_PATH} />
      <Route exact path={pathConstants.HOME_PATH} />
    </Fragment>
  );
};

export default NavRouters;
