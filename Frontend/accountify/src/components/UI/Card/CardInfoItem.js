import React from 'react';
import Typography from '@material-ui/core/Typography';

const CardInfoItem = props => {
  const { label, value, className } = props;

  return (
    <div className={className}>
      <Typography variant="subtitle1" color="textSecondary" component="label">
        {label}
      </Typography>
      <Typography variant="body1" color="textSecondary" component="p">
        {value}
      </Typography>
    </div>
  );
};

export default CardInfoItem;
