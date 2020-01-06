import { Action, Reducer } from 'redux';

// -----------------
// STATE - This defines the type of data maintained in the Redux store.

export interface MainState {
    backgroundColor: string;
}

// ----------------
// ACTION CREATORS - These are functions exposed to UI components that will trigger a state transition.
// They don't directly mutate state, but they can have external side-effects (such as loading data).

export const actionCreators = {

};

// ----------------
// REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.

export const reducer: Reducer<MainState> = (state: MainState | undefined, incomingAction: Action): MainState => {
  if (state === undefined) {
    return { backgroundColor: 'white' };
  }
  return state; 
};
