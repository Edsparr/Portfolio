import * as React from 'react';
import ProjectList from './ProjectList';
import { makeStyles } from '@material-ui/core';
import '../css/Portfolio.css';

export const Portfolio = () => {
  return (<div className="portfolioContainer">
      <ProjectList />
    </div>
  );
}

export default Portfolio;