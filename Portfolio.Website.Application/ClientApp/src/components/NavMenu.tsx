import * as React from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';



export default class NavMenu extends React.PureComponent<{}, { isOpen: boolean }> {
    public state = {
        isOpen: false
    };

    public render() {
        return (
          <header>
            <Navbar className="navbar-expand-sm navbar-toggleable-sm box-shadow mb-3" light>
              <Container>
                <NavbarToggler onClick={this.toggle} className="mr-2" />
                <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={this.state.isOpen} navbar>
                  <ul className="navbar-nav flex-grow">
                    <NavItem>
                      <NavLink tag={Link} className="text-light" to="/">Home</NavLink>
                    </NavItem>
                    <NavItem>
                      <NavLink tag={Link} className="text-light" to="/portfolio">Portfolio</NavLink>
                    </NavItem>
                    <NavItem>
                      <NavLink tag={Link} className="text-light" to="/about">About</NavLink>
                    </NavItem>
                  </ul>
                </Collapse>
              </Container>
            </Navbar>
          </header>
        );
    }

    private toggle = () => {
        this.setState({
            isOpen: !this.state.isOpen
        });
    }
}


