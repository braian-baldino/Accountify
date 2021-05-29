import React, { useState } from 'react';
import { makeStyles } from '@material-ui/core/styles';
import { MuiThemeProvider, createMuiTheme } from '@material-ui/core/styles';
import FormControl from '@material-ui/core/FormControl';
import InputLabel from '@material-ui/core/InputLabel';
import Select from '@material-ui/core/Select';
import MenuItem from '@material-ui/core/MenuItem';

const theme = createMuiTheme({
  palette: {
    primary: { main: '#2ea6a4' },
    secondary: { main: '#294b85' },
  },
});

const useStyles = makeStyles(theme => ({
  formControl: {
    margin: theme.spacing(1),
    minWidth: 120,
  },
  selectEmpty: {
    marginTop: theme.spacing(2),
  },
}));

const Dropdown = props => {
  const { id, placeHolder, menuItems, onChange, value } = props;
  // const [value, setValue] = useState();
  const innerStyles = useStyles();

  // const handleChange = event => {
  //   setValue(event.target.value);
  // };

  return (
    <div>
      <MuiThemeProvider theme={theme}>
        <FormControl variant="standard" className={innerStyles.formControl}>
          <InputLabel id={'simple-select-label' + id}>{placeHolder}</InputLabel>
          <Select
            labelId={'simple-select-label' + id}
            id={id}
            value={value}
            onChange={onChange}
          >
            {menuItems.map((item, i) => {
              return (
                <MenuItem key={i} value={item.value}>
                  {item.label}
                </MenuItem>
              );
            })}
          </Select>
        </FormControl>
      </MuiThemeProvider>
    </div>
  );
};

export default Dropdown;
