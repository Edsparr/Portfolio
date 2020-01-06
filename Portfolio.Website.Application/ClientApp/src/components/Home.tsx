import * as React from 'react';
import { connect } from 'react-redux';
import ProjectList from './ProjectList';
import HomeAlternative from './HomeAlternative';
import '../css/Home.css';
import { makeStyles } from '@material-ui/core';

import PortfolioImage from '../icons/home/portfolioIcon.png';
import ProfileImage from '../icons/home/myProfile.png';

class Home extends React.Component {

  render() {
    return (<div>
      <HomeAlternativeCollection />
    </div>);
  }

}

const HomeAlternativeCollection = () => {
  const classes = useStyles();
  return (
    <div className={classes.alternativesWrapper}>
      <HomeAlternative color="white" link="/portfolio" image={PortfolioImage} text="Portfolio" />
      <HomeAlternative color="black" link="/about" image={ProfileImage} text="About" />
    </div>

  )
}  

const useStyles = makeStyles({
  alternativesWrapper: {
    display: 'flex',
    justifyContent: 'center',
    listStyle: 'none',
    padding: '0'

  },

});

  export default connect()(Home);
