import React from 'react';
import './App.css';
import Navbar from './components/Navbar';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import Home from './pages/Home';
import Loans from './pages/Loans';
import AddLoan from './pages/addLoan';

function App() {
  return (
    <>
      <Router>
        <Navbar />
        <Switch>
          <Route path='/' exact component={Home} />
          <Route path='/loans' component={Loans} />
          <Route path='/addLoans' component={AddLoan} />
        </Switch>
      </Router>
    </>
  );
}

export default App;
