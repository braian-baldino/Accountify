import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import { MuiThemeProvider, createMuiTheme } from '@material-ui/core/styles';
import Fab from '@material-ui/core/Fab';
import AddIcon from '@material-ui/icons/Add';

const theme = createMuiTheme({
  palette: {
    primary: { main: '#01fdf9' },
    secondary: { main: '#294b85' },
  },
});

const useStyles = makeStyles(theme => ({
  root: {
    '& > *': {
      margin: theme.spacing(1),
    },
    position: 'fixed',
    right: '3%',
    bottom: '5%',
  },
}));

const AddNew = props => {
  const { onClick } = props;
  const innerStyles = useStyles();
  return (
    <MuiThemeProvider theme={theme}>
      <div className={innerStyles.root} onClick={onClick}>
        <Fab color="primary" aria-label="add">
          <AddIcon />
        </Fab>
      </div>
    </MuiThemeProvider>
  );
};

export default AddNew;
