import * as React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import ProjectList from './components/ProjectList';
import Portfolio from './components/Portfolio';
import './custom.css'

export default () => (
  <Layout>
    <Route exact path='/' component={Home} />
    <Route path='/portfolio' component={Portfolio} />
  </Layout>
);
