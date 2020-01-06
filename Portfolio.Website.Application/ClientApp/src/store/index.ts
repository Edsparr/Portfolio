import * as ProjectList from './ProjectList';
import * as Main from './Main';

export interface ApplicationState {
  main: Main.MainState | undefined;
  projectList: ProjectList.ProjectListState | undefined;
}

export const reducers = {
  main: Main.reducer,
  projectList: ProjectList.reducer
};

export interface AppThunkAction<TAction> {
    (dispatch: (action: TAction) => void, getState: () => ApplicationState): void;
}
