import * as React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import { Link } from 'react-router-dom';
import Portfolio from './Portfolio';
import '../css/HomeAlternative.css';

type HomeAlternativeProps = {
  image: string,
  text: string,
  link: string,
  color: string
}

export const HomeAlternative = (props: HomeAlternativeProps) => {

  return (
    <Link to={props.link}>
      <div className='container' >
        <img className='image' src={props.image} />
        <h1 style={{ color: props.color}} className='text'>{props.text}</h1>
      </div>

    </Link>
  )
};

export default HomeAlternative;