import React from 'react';
import Card from '@material-ui/core/Card';
import Divider from '@material-ui/core/Divider';
import CardActionArea from '@material-ui/core/CardActionArea';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import Button from '@material-ui/core/Button';
import Typography from '@material-ui/core/Typography';
import styles from './DataCard.module.scss';
import CardInfoItem from './CardInfoItem';

const DataCard = props => {
  const { object, labels, keys, headerKey, onClick } = props;
  const dynamicHeaderClass = [styles.CardHeader];

  //!data.positive
  if (!object['positive']) {
    dynamicHeaderClass.push(styles.Negative);
  }

  return (
    <Card className={styles.Card} onClick={onClick}>
      <CardActionArea>
        <CardContent className={dynamicHeaderClass.join(' ')}>
          <Typography align="center" gutterBottom variant="h5" component="h2">
            {object[headerKey]}
          </Typography>
          <Divider />
        </CardContent>
        <CardContent>
          <div className={styles.CardItemsList}>
            {keys.map((key, i) => {
              return (
                <CardInfoItem
                  className={styles.CardItem}
                  key={object['id'] + i}
                  label={labels[i]}
                  value={object[key]}
                />
              );
            })}
          </div>
        </CardContent>
      </CardActionArea>
      <CardActions className={styles.BottomIcons}>
        <Button size="small" color="primary">
          PDF
        </Button>
        <Button size="small" color="primary">
          Eliminar
        </Button>
      </CardActions>
    </Card>
  );
};

export default DataCard;
