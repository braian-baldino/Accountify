import classes from './App.scss';
import Header from './components/Layout/Header';
import NavRouters from './components/routers/NavRouters';
import NavBar from './components/UI/NavBar';
import mockedNavLinks from './dummy/NavLinks';

function App() {
  return (
    <div className={classes.App}>
      <Header>
        <NavBar links={mockedNavLinks} />
      </Header>
      <NavRouters />
    </div>
  );
}

export default App;
