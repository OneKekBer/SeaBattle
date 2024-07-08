// slices/boardSlice.ts
import { createSlice, createAsyncThunk, PayloadAction } from '@reduxjs/toolkit'
import axios from 'axios'
import { IBoard } from '../interfaces/IBoard'
import { convertStringToArray } from '../helpers/Converter'

// Define a type for the slice state
interface BoardState {
	board: string[][]
	status: 'idle' | 'loading' | 'succeeded' | 'failed'
	error: string | null
}

// Define the initial state using that type
const initialState: BoardState = {
	board: [],
	status: 'idle',
	error: null,
}

export const fetchBoard = createAsyncThunk<
	IBoard,
	void,
	{ rejectValue: string }
>('board/fetchBoard', async (_, { rejectWithValue }) => {
	try {
		const response = await axios.get(`${import.meta.env.VITE_API_URL}board`)
		return response.data as IBoard
	} catch (error) {
		return rejectWithValue('Failed to fetch board')
	}
})

export const boardSlice = createSlice({
	name: 'board',
	initialState,
	reducers: {
		updateBoard: (state, action: PayloadAction<IBoard>) => {
			state.board = convertStringToArray(action.payload)
		},
	},
	extraReducers: builder => {
		builder
			.addCase(fetchBoard.pending, state => {
				state.status = 'loading'
			})
			.addCase(fetchBoard.fulfilled, (state, action) => {
				state.status = 'succeeded'
				state.board = convertStringToArray(action.payload)
			})
			.addCase(fetchBoard.rejected, (state, action) => {
				state.status = 'failed'
				state.error = action.payload || 'Something went wrong'
			})
	},
})

export const { updateBoard } = boardSlice.actions

export default boardSlice.reducer
