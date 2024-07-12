import { useState } from 'react'

type PanelState = 'Empty' | 'Miss' | 'Shooted' // shooted не доза!

const getColorForPanel = (panelState: PanelState) => {
	if (panelState === 'Miss') return 'bg-yellow-200'
	else if (panelState === 'Shooted') return 'bg-red-200'
	else return 'bg-slate-200'
}

const Panel = ({
	cellIndex,
	rowIndex,
}: {
	cellIndex: number
	rowIndex: number
}) => {
	const [panelState, setPanelState] = useState<PanelState>('Empty')

	const handlePlateClick = async (cellIndex: number, rowIndex: number) => {
		try {
			// Log the clicked coordinates (adjusting for 1-based index)
			console.log(`Clicked at (${cellIndex + 1}, ${rowIndex + 1})`)

			// Send POST request to shoot endpoint
			const res = await fetch(`${import.meta.env.VITE_API_URL}shoot`, {
				method: 'POST',
				headers: {
					'Content-Type': 'application/json', // corrected content type
				},
				body: JSON.stringify({ x: cellIndex, y: rowIndex }),
			})

			// Check if request was successful
			if (!res.ok) {
				throw new Error('Problem with fetch shoot')
			}
			const data = await res.json()
			// Dispatch fetchBoard action to update the board state
			console.log(data.state)
			setPanelState(data.state)
			// if (data.state === 'Miss') setPanelState()
		} catch (error) {
			console.error('Error handling plate click:', error)
			// Handle errors, such as displaying an error message or logging
		}
	}

	return (
		<span
			onClick={() => handlePlateClick(cellIndex, rowIndex)}
			className={`w-[50px] border border-gray-400 h-[50px] ${getColorForPanel(
				panelState
			)}`}
		></span>
	)
}

export default Panel
