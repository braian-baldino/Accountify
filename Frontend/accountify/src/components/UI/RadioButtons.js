import React, { useState } from 'react';
import { MuiThemeProvider, createMuiTheme } from '@material-ui/core/styles';
import Radio from '@material-ui/core/Radio';
import RadioGroup from '@material-ui/core/RadioGroup';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import FormControl from '@material-ui/core/FormControl';
import FormLabel from '@material-ui/core/FormLabel';

const theme = createMuiTheme({
  palette: {
    primary: { main: '#2ea6a4' },
    secondary: { main: '#294b85' },
  },
});

const RadioButtons = props => {
  const { items, header, row } = props;
  const [value, setValue] = useState('all');

  const handleChange = event => {
    setValue(event.target.value);
  };

  return (
    <div>
      <MuiThemeProvider theme={theme}>
        <FormControl component="fieldset">
          <FormLabel component="legend">{header}</FormLabel>
          <RadioGroup
            aria-label={header}
            name={header}
            value={value}
            onChange={handleChange}
            row={row}
          >
            {items.map((item, i) => {
              return (
                <FormControlLabel
                  key={i}
                  value={item.value}
                  control={<Radio />}
                  label={item.label}
                />
              );
            })}
          </RadioGroup>
        </FormControl>
      </MuiThemeProvider>
    </div>
  );
};

export default RadioButtons;
